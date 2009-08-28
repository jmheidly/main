﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Microsoft Public License. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the  Microsoft Public License, please send an email to 
 * dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Microsoft Public License.
 *
 * You must not remove this notice, or any other, from this software.
 *
 *
 * ***************************************************************************/

using System;
using IronPython.Runtime.Types;
using Microsoft.Scripting;
using IronPython.Runtime.Exceptions;


namespace IronPythonTest.interop.net.type.clrtype {
    ///--Helpers--
    public class Factory {
        public static T Get<T>() where T : new() {
            return new T();
        }
    }


    ///--Positive Scenarios--
    #region sanity derived
    public class SanityDerived : PythonExceptions.BaseException {
        public SanityDerived(PythonType pt) : base(pt) { }
    }
    #endregion

    #region sanity
    public class Sanity : IPythonObject {
        private PythonType _pythonType;
        private IAttributesCollection _dict;


        public Sanity(PythonType param) {
            _pythonType = param;
        }

        #region IPythonObject Members

        IAttributesCollection IPythonObject.Dict {
            get { return _dict; }
        }

        IAttributesCollection IPythonObject.SetDict(IAttributesCollection dict) {
            System.Threading.Interlocked.CompareExchange<IAttributesCollection>(ref _dict, dict, null);
            return _dict;
        }

        bool IPythonObject.ReplaceDict(IAttributesCollection dict) {
            return false;
        }

        PythonType IPythonObject.PythonType {
            get { return _pythonType; }
        }

        void IPythonObject.SetPythonType(PythonType newType) {
            _pythonType = newType;
        }

        object[] IPythonObject.GetSlots() { return null; }
        object[] IPythonObject.GetSlotsCreate() { return null; }

        #endregion
    }
    #endregion

    #region sanity non-standard constructor
    public class SanityUniqueConstructor : IPythonObject {
        private PythonType _pythonType;
        private IAttributesCollection _dict;

        public SanityUniqueConstructor(PythonType param, Int32 param2) { }

        #region IPythonObject Members

        IAttributesCollection IPythonObject.Dict {
            get { return _dict; }
        }

        IAttributesCollection IPythonObject.SetDict(IAttributesCollection dict) {
            System.Threading.Interlocked.CompareExchange<IAttributesCollection>(ref _dict, dict, null);
            return _dict;
        }

        bool IPythonObject.ReplaceDict(IAttributesCollection dict) {
            return false;
        }

        PythonType IPythonObject.PythonType {
            get { return _pythonType; }
        }

        void IPythonObject.SetPythonType(PythonType newType) {
            _pythonType = newType;
        }

        object[] IPythonObject.GetSlots() { return null; }
        object[] IPythonObject.GetSlotsCreate() { return null; }

        #endregion
    }
    #endregion

    #region sanity constructor overloads
    public class SanityConstructorOverloads : IPythonObject {
        private PythonType _pythonType;
        private IAttributesCollection _dict;
        public Object MyField;


        public SanityConstructorOverloads(PythonType param) {
            _pythonType = param;
            param.Name = "first";
        }

        public SanityConstructorOverloads(PythonType param, Int32 param2) {
            _pythonType = param;
            param.Name = "second";
        }

        #region IPythonObject Members

        IAttributesCollection IPythonObject.Dict {
            get { return _dict; }
        }

        IAttributesCollection IPythonObject.SetDict(IAttributesCollection dict) {
            System.Threading.Interlocked.CompareExchange<IAttributesCollection>(ref _dict, dict, null);
            return _dict;
        }

        bool IPythonObject.ReplaceDict(IAttributesCollection dict) {
            return false;
        }

        PythonType IPythonObject.PythonType {
            get { return _pythonType; }
        }

        void IPythonObject.SetPythonType(PythonType newType) {
            _pythonType = newType;
        }

        object[] IPythonObject.GetSlots() { return null; }
        object[] IPythonObject.GetSlotsCreate() { return null; }

        #endregion
    }
    #endregion

    #region sanity generic
    public class SanityGeneric<T> : IPythonObject {
        private PythonType _pythonType;
        private IAttributesCollection _dict;


        public SanityGeneric(PythonType param) {
            _pythonType = param;
        }

        #region IPythonObject Members

        IAttributesCollection IPythonObject.Dict {
            get { return _dict; }
        }

        IAttributesCollection IPythonObject.SetDict(IAttributesCollection dict) {
            System.Threading.Interlocked.CompareExchange<IAttributesCollection>(ref _dict, dict, null);
            return _dict;
        }

        bool IPythonObject.ReplaceDict(IAttributesCollection dict) {
            return false;
        }

        PythonType IPythonObject.PythonType {
            get { return _pythonType; }
        }

        void IPythonObject.SetPythonType(PythonType newType) {
            _pythonType = newType;
        }

        object[] IPythonObject.GetSlots() { return null; }
        object[] IPythonObject.GetSlotsCreate() { return null; }

        #endregion
    }
    #endregion

    #region sanity generic constructor
    public class SanityGenericConstructor<T> : IPythonObject {
        private PythonType _pythonType;
        private IAttributesCollection _dict;


        public SanityGenericConstructor(T param) {
            _pythonType = (PythonType)(Object)param;
        }

        #region IPythonObject Members

        IAttributesCollection IPythonObject.Dict {
            get { return _dict; }
        }

        IAttributesCollection IPythonObject.SetDict(IAttributesCollection dict) {
            System.Threading.Interlocked.CompareExchange<IAttributesCollection>(ref _dict, dict, null);
            return _dict;
        }

        bool IPythonObject.ReplaceDict(IAttributesCollection dict) {
            return false;
        }

        PythonType IPythonObject.PythonType {
            get { return _pythonType; }
        }

        void IPythonObject.SetPythonType(PythonType newType) {
            _pythonType = newType;
        }

        object[] IPythonObject.GetSlots() { return null; }
        object[] IPythonObject.GetSlotsCreate() { return null; }

        #endregion
    }
    #endregion

    #region sanity constructor but no IPythonObject
    public class SanityNoIPythonObject {
        public SanityNoIPythonObject(PythonType pt) {
        }
    }
    #endregion

    #region sanity with parameterless constructor
    public class SanityParameterlessConstructor : IPythonObject {
        private static PythonType _PythonType;
        public static int WhichConstructor;
        private IAttributesCollection _dict;


        public SanityParameterlessConstructor(PythonType param) {
            _PythonType = param;
            WhichConstructor = 1;
        }

        public SanityParameterlessConstructor() {
            WhichConstructor = 2;
        }

        #region IPythonObject Members

        IAttributesCollection IPythonObject.Dict {
            get { return _dict; }
        }

        IAttributesCollection IPythonObject.SetDict(IAttributesCollection dict) {
            System.Threading.Interlocked.CompareExchange<IAttributesCollection>(ref _dict, dict, null);
            return _dict;
        }

        bool IPythonObject.ReplaceDict(IAttributesCollection dict) {
            return false;
        }

        PythonType IPythonObject.PythonType {
            get { return _PythonType; }
        }

        void IPythonObject.SetPythonType(PythonType newType) {
            _PythonType = newType;
        }

        object[] IPythonObject.GetSlots() { return null; }
        object[] IPythonObject.GetSlotsCreate() { return null; }

        #endregion
    }
    #endregion


    ///--Negative Scenarios--

    #region negative empty
    public class NegativeEmpty { }
    #endregion

    #region negative no constructor, but implements IPythonOjbect
    public class NegativeNoConstructor : IPythonObject {
        #region IPythonObject Members

        public Microsoft.Scripting.IAttributesCollection Dict {
            get { throw new NotImplementedException(); }
        }

        public Microsoft.Scripting.IAttributesCollection SetDict(Microsoft.Scripting.IAttributesCollection dict) {
            throw new NotImplementedException();
        }

        public bool ReplaceDict(Microsoft.Scripting.IAttributesCollection dict) {
            throw new NotImplementedException();
        }

        public PythonType PythonType {
            get { return TypeCache.Int32; }
        }

        public void SetPythonType(PythonType newType) {
            throw new NotImplementedException();
        }

        public object[] GetSlots() {
            throw new NotImplementedException();
        }

        public object[] GetSlotsCreate() {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion
}